import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import{MatSidenavModule} from '@angular/material/sidenav'; //menú de material 
import{MatTableModule} from '@angular/material/table';
import{MatDialogModule} from '@angular/material/dialog';
import{MatButtonModule} from '@angular/material/button';
import{MatInputModule} from '@angular/material/input';
import{MatCardModule} from '@angular/material/card';
import{MatSnackBarModule} from '@angular/material/snack-bar';//para agregar esta cosa, tuve que agregra una linea en el package.json y tsconfig.json
import { HomeComponent } from './home/home.component';
import { ClienteComponent } from './cliente/cliente.component';
import { DialogClienteComponent } from './cliente/dialog/dialogcliente.component';
import{DialogDeleteComponent} from './common/delete/dialogdelete.component';
import{LoginComponent} from '././login/login.component';

import{HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';
import { JwtInterceptor } from './security/jwt.interseptor';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    ClienteComponent,
    DialogClienteComponent,
    DialogDeleteComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatTableModule,
    HttpClientModule,
    MatDialogModule,
    MatButtonModule,
    MatInputModule,
    MatCardModule,
    MatSnackBarModule,
    FormsModule,
    ReactiveFormsModule

  ],
  //Dialogs
  entryComponents: [
    DialogClienteComponent,
    DialogDeleteComponent
  ],
  providers: [
    {provide:HTTP_INTERCEPTORS,useClass: JwtInterceptor,multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
