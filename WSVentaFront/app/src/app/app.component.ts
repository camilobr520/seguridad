import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from './Interfaces/usuario';
import { ApiauthService } from './services/apiauth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  usuario:Usuario={};

  constructor(public apiauth:ApiauthService,private router:Router){
      this.apiauth.usuario.subscribe(res=>{
          //el subscribe me permite actualizar  la información del login cada vez que el objeto 
          //usuarioSubject cambie
           this.usuario=res;
      });
  }


  logout(){
    this.apiauth.logout();
    this.router.navigate(['login'])
  }
}
