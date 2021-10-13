import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';


@Component({
  selector: 'app-room-managment',
  templateUrl: './room-managment.component.html',
  styleUrls: ['./room-managment.component.css']
})
export class RoomManagmentComponent implements OnInit {

  addingRoom: boolean = false;
  deletingRoom: boolean = false;
  modifyingRoom: boolean = false;
  
  
  Room_id: string ='';
  Theater_name: string = '';
  Row_number: string = '';
  Column_number: string = '';
  Capacity: string = '';

  rooms: any[] = [];




constructor(
  public swal: SwalService,
  public dialogRef: MatDialogRef<RoomManagmentComponent>) { }

  ngOnInit(): void {
  }


  selectRoom(event: any) {
    this.Room_id = event.Room_id;
    this.Theater_name = event.Theater_name;
    this.Row_number = event.Row_number;
    this.Column_number = event.Column_number;
    this.Capacity = event.Capacity;
  }


  submitModify() {
    if (
      this.Room_id !== '' &&
      this.Theater_name !== '' &&
      this.Row_number !== '' &&
      this.Column_number !== '' &&
      this.Capacity !== '' 
    ) {
      this.swal.showSuccess(
        'Sala modificada',
        'Sala modificada con éxito'
      );
    } else {
      this.swal.showError(
        'Error al modificar la sala',
        'Los datos ingresados son insuficientes o la sala no existe en nuestra base de datos'
      );
    }
  }


  deleteRoom() {
    for (let i = 0; i < this.rooms.length; i++) {
      if (this.rooms[i].Original_name === this.Room_id) {
        this.rooms.splice(i, 1);
        this.swal.showSuccess(
          'Sala eliminada',
          'Sala eliminada con éxito'
        );
        return;
      }
    }
    this.swal.showError(
      'Error al eliminar la sala',
      'La sala no se encuentra en la base de datos'
    );
  }

  close(): void {
    this.dialogRef.close();
  }

}