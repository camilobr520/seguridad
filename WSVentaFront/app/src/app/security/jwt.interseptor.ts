//el interseptor intersepta todas las solicitudes de los servicios para agregarle 
//el token siempre que halla login

import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { ApiauthService } from "../services/apiauth.service";

@Injectable()
export class JwtInterceptor implements HttpInterceptor{

    constructor(private apiauthservice:ApiauthService){

    }

    intercept(request:HttpRequest<any>,next:HttpHandler):Observable<HttpEvent<any>>{
        const usuario=this.apiauthservice.usuarioData;
        if(usuario){
            //clonar request para agregarle un atributo nuevo a las solicitudes http de los servicios
            request=request.clone({
              setHeaders:{
                  Authorization:`Bearer ${usuario.token}`
              }
            });
        }
        //si no hay sesion, simplemente el request se envia como venia, sin token
        return next.handle(request);
    }
}