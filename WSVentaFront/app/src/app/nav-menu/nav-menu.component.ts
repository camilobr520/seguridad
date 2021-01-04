import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from '../Interfaces/usuario';
import { ApiauthService } from '../services/apiauth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent  {
  usuario:Usuario={};

  constructor(public apiauth:ApiauthService,private router:Router) { 
    this.apiauth.usuario.subscribe(res=>{
      //el subscribe me permite actualizar  la información del login cada vez que el objeto 
      //usuarioSubject cambie
       this.usuario=res;
  })
}

 
  logout(){
    this.apiauth.logout();
    this.router.navigate(['login'])
  }
}

