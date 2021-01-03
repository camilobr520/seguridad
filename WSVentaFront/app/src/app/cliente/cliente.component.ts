import { Component, OnInit, ɵConsole } from '@angular/core';
import { ApiclienteService } from '../services/apicliente.service';
import {Response} from '../Interfaces/response';
import {DialogClienteComponent} from './dialog/dialogcliente.component';
import {MatDialog} from '@angular/material/dialog';
import { cliente } from '../Interfaces/cliente';
import { DialogDeleteComponent } from '../common/delete/dialogdelete.component';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
 
  public lst:any[]=[];
  public columnas:string[]=['id','nombre','actions'];
  readonly with:string='300';

  constructor(
    private apiCliente:ApiclienteService,
    public dialog:MatDialog,
    public snackBar:MatSnackBar,
  ) {
 
   }

  ngOnInit(): void {
    this.getClientes();
  }

  getClientes(){
    this.apiCliente.getClientes().subscribe(response=>{
    this.lst=response.data;
    console.log(response.data);
   })
  }

  openAdd(){
    const dialogRef=this.dialog.open(DialogClienteComponent,{
      width:this.with
    });
    dialogRef.afterClosed().subscribe(result=>{
      this.getClientes();
    })
  }

  openEdit(cliente:cliente){
    const dialogRef=this.dialog.open(DialogClienteComponent,{
      width:this.with,
      data:cliente
    });
    dialogRef.afterClosed().subscribe(result=>{
      this.getClientes();
    })
  }

delete(cliente:cliente){
  const dialogRef=this.dialog.open(DialogDeleteComponent,{
    width:this.with
  });
  dialogRef.afterClosed().subscribe(result=>{
    //el dialog generico delete retorna true/false
    if(result){
       this.apiCliente.deleteClientes(cliente.id).subscribe(response=>{
         if(response.success===1){
           this.snackBar.open('Cliente eliminado con éxito','',{
             duration:2000
           });
           this.getClientes();
         }

       })
    }
  })
}
}
