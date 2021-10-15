import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-room-managment',
  templateUrl: './room-managment.component.html',
  styleUrls: ['./room-managment.component.css'],
})
export class RoomManagmentComponent implements OnInit {
  addingRoom: boolean = false;
  deletingRoom: boolean = false;
  modifyingRoom: boolean = false;
  theaters: any[] = [];
  Room_id: string = '';
  Theater_name: string = '';
  Row_number: string = '';
  Column_number: string = '';
  Capacity: string = '';

  rooms: any[] = [];

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<RoomManagmentComponent>,
    private backend: BackendService
  ) {}

  ngOnInit(): void {
    this.backend.get_request('Admin/Sucursales', null).subscribe((cines) => {
      this.theaters = cines;
    });
  }

  selectRoom(event: any) {
    this.Room_id = event.number;
  }
  selectSucursal($event: any) {
    this.Theater_name = $event;
    console.log(this.Theater_name);

    this.backend
      .get_request('Admin/Sucursales/Room', { cinema_name: this.Theater_name })
      .subscribe((value) => {
        console.log(value);

        this.rooms = value;
      });
  }
  create() {
    const data = {
      cinemaName: this.Theater_name,
      rows: this.Row_number,
      number: this.Room_id,
      columns: this.Column_number,
      restrictionPercent: 0,
    };
    console.log(data);

    this.backend
      .post_request('Admin/Sucursales/Room', data)
      .subscribe((value) => {
        console.log(value);
        this.swal.showSuccess('Proceso exitoso', 'Sala creada con éxito');
      });
  }
  submitModify() {
    if (
      this.Room_id !== '' &&
      this.Theater_name !== '' &&
      this.Row_number !== '' &&
      this.Column_number !== '' &&
      this.Capacity !== ''
    ) {
      this.swal.showSuccess('Sala modificada', 'Sala modificada con éxito');
    } else {
      this.swal.showError(
        'Error al modificar la sala',
        'Los datos ingresados son insuficientes o la sala no existe en nuestra base de datos'
      );
    }
  }

  deleteRoom() {
    const data = {
      cinema_name: this.Theater_name,
      room_number: this.Room_id,
    };
    console.log(data);
    this.backend
      .delete_request('Admin/Sucursales/Room', data)
      .subscribe((value) => {
        this.swal.showSuccess('Sala eliminada', 'Sala eliminada con éxito');
      });
    this.swal.showError(
      'Error al eliminar la sala',
      'La sala no se encuentra en la base de datos'
    );
  }

  close(): void {
    this.dialogRef.close();
  }
}
