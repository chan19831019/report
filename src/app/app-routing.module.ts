import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { Report4Component } from './report4/report4.component';
import { Report5Component } from './report5/report5.component';
import { Report6Component } from './report6/report6.component';
import { Report7Component } from './report7/report7.component';
import { Report8Component } from './report8/report8.component';
import { Report9Component } from './report9/report9.component';
import { Report10Component } from './report10/report10.component';
import { Report11Component } from './report11/report11.component';
import { Report12Component } from './report12/report12.component';
import { Report13Component } from './report13/report13.component';
import { Report14Component } from './report14/report14.component';
import { Report15Component } from './report15/report15.component';
import { Report16Component } from './report16/report16.component';

const routes: Routes = [
  { path: 'report4', component: Report4Component },
  { path: 'report5', component: Report5Component },
  { path: 'report6', component: Report6Component },
  {
    path: 'report7', component: Report7Component
  },
  {
    path: 'report8', component: Report8Component
  },
  {
    path: 'report9', component: Report9Component
  },
  {
    path: 'report10', component: Report10Component
  },
  {
    path: 'report11', component: Report11Component
  },
  {
    path: 'report12', component: Report12Component
  },
  {
    path: 'report13', component: Report13Component
  },
  {
    path: 'report14', component: Report14Component
  },
  {
    path: 'report15', component: Report15Component
  },
  {
    path: 'report16', component: Report16Component
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
