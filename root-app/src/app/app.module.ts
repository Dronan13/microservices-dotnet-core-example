import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SideNavOuterToolbarModule, SideNavInnerToolbarModule, SingleCardModule } from './layouts';
import { FooterModule, LoginFormModule } from './shared/components';
import { AuthService, ScreenService, AppInfoService } from './shared/services';
import { ArticlesComponent } from './pages/articles/articles.component';
import { BooksComponent } from './pages/books/books.component';
import { ChaptersComponent } from './pages/chapters/chapters.component';
import { ConferencesComponent } from './pages/conferences/conferences.component';
import { ResumeComponent } from './pages/resume/resume.component';
import { HttpClientModule } from '@angular/common/http';
import { DxDataGridModule, DxSelectBoxModule, DxButtonModule } from 'devextreme-angular';
@NgModule({
  declarations: [
    AppComponent,
    ArticlesComponent,
    BooksComponent,
    ChaptersComponent,
    ConferencesComponent,
    ResumeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SideNavOuterToolbarModule,
    SideNavInnerToolbarModule,
    SingleCardModule,
    FooterModule,
    LoginFormModule,
    DxDataGridModule,
    DxSelectBoxModule,
    DxButtonModule,
  ],
  providers: [AuthService, ScreenService, AppInfoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
