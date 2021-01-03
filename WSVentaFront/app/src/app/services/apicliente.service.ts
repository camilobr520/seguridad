import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {Response} from '../Interfaces/response';
import{cliente} from '../Interfaces/cliente';

const httpOption={
  headers:new HttpHeaders({
    'Content-Type':'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiclienteService {
  url:string='https://localhost:44381/api/cliente';
  constructor(
    private http:HttpClient
  ) { }

  getClientes():Observable<Response>{
     return this.http.get<Response>(this.url); 
  }
  addClientes(cliente:cliente):Observable<Response>{
    return this.http.post<Response>(this.url,cliente,httpOption); 
  }
   editClientes(cliente:cliente):Observable<Response>{
  return this.http.put<Response>(this.url,cliente,httpOption); 
 } 
   deleteClientes(id:number):Observable<Response>{
  return this.http.delete<Response>(`${this.url}/${id}`); 
 }
}


