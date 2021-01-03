import { HttpClient,HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import { Usuario } from "../Interfaces/usuario";
import{Response} from './../Interfaces/response'
import{map} from 'rxjs/operators';
import { Router } from "@angular/router";
import { Login } from "../Interfaces/login";


const httpOption={
    headers:new HttpHeaders({
      'Content-Type':'application/json'
    })
  };

@Injectable({
    providedIn:'root'
})
export class ApiauthService{
   url:string='https://localhost:44381/api/User/login';

   private usuarioSubject: BehaviorSubject<Usuario>;
   public usuario:Observable<Usuario> 

   public get usuarioData():Usuario{
       return this.usuarioSubject.value;
   }

   constructor(private http:HttpClient,private router:Router){
      var us:Usuario=JSON.parse(localStorage.getItem('user')|| '{}');
      this.usuarioSubject=new BehaviorSubject<Usuario>(us);
      //el atributo usuario es un observable para acceder a los datos de usuarioSubject
      this.usuario=this.usuarioSubject.asObservable();
   }



   //pipe sirve para ejecutar funciones que hacen algo con lo que traiga el observable
   login(login:Login):Observable<Response>{
      return this.http.post<Response>(this.url,login,httpOption).pipe(
        map(res=>{
            if(res.success==1){
                const user:Usuario=res.data;
                //guardar localstorage
                localStorage.setItem('user',JSON.stringify(user));
                //next indica que todos los subcribes del observable se actualizen con el nuevo cambio de user
                this.usuarioSubject.next(user);
            }
            return res;
        })
      );
   }

   logout(){
       localStorage.removeItem('user');
       //estoy seteando el objeto vacio
       this.usuarioSubject.next({email:'',token:''});

   }
}