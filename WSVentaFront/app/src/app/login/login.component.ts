import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { ApiauthService } from "../services/apiauth.service";
import {FormGroup, FormControl,FormBuilder, Validators} from '@angular/forms';


@Component({templateUrl:'login.component.html',styleUrls:['login.component.css']})

export class LoginComponent implements OnInit{

    public loginForm=this.fb.group({
      email:['',Validators.required],
      password:['',Validators.required]
    });

constructor(
    public apiauthservice:ApiauthService,
    private router:Router,
    private fb:FormBuilder
    ){
    //redirigir al home si el usuario esta logeado
    if(this.apiauthservice.usuarioData.token){
        this.router.navigate(['/']);
    }

}
    ngOnInit(){

    }

    login(){
        this.apiauthservice.login(this.loginForm.value).subscribe(response=>{
        if(response.success==1){
               this.router.navigate(['/']);
        }
        })
    }
}