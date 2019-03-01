import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './angular/home.component';
import { CreatemployeeComponent } from './angular/createmployee.component';
import { ContactComponent } from './angular/contact.component';
import { LoginComponent } from './angular/login.component';

const routes: Routes = [

  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'create', component: CreatemployeeComponent },
  { path: 'create/:id', component: CreatemployeeComponent },
  { path: 'contact', component: ContactComponent},
  { path: 'login', component: LoginComponent},
  { path: '**', redirectTo: 'home', pathMatch:'full'}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const RoutingComponents =[
  HomeComponent,
  CreatemployeeComponent,
  ContactComponent,
  LoginComponent
]

