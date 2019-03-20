import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import CustomStore from 'devextreme/data/custom_store';

const URL = 'http://localhost:4002/api-cv/articles';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})

export class ArticlesComponent implements OnInit {
  dataSource: any;
  refreshMode: string;

  onRowUpdating(e) {
    e.newData = this.extend(e.oldData, e.newData);
  }

  extend(a, b) {
    for (const key in b) {
        if (b.hasOwnProperty(key)) {
            a[key] = b[key];
        }
    }
    return a;
  }

  constructor(private http: HttpClient) {
    this.refreshMode = 'full';
    this.dataSource = new CustomStore({
      key: 'ArticleId',
      load: () => this.sendRequest(URL),
      insert: (values) => this.sendRequest(URL, 'POST', values),
      update: (key, values) => this.sendRequest(URL, 'PUT', { key, values }),
      remove: (key) => this.sendRequest(URL, 'DELETE', { key })
  });
  }

  ngOnInit() {
  }

  sendRequest(url: string, method: string = 'GET', data: any = {}): any {
    let result;
    switch (method) {
        case 'GET':
            result = this.http.get(url);
            break;
        case 'PUT':
            result = this.http.put(`${url}/${data.key}`, data.values);
            break;
        case 'POST':
            result = this.http.post(url, data);
            break;
        case 'DELETE':
            result = this.http.delete(`${url}/${data.key}`);
            break;
    }

    return result
        .toPromise()
        // tslint:disable-next-line:no-shadowed-variable
        .then((data: any) => {
          return method === 'GET' ? data : data;
        })
        .catch(e => {
            throw e && e.error && e.error.Message;
        });
  }

}
