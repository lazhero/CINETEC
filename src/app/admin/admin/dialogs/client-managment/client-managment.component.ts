import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { TheatherManagmentComponent } from '../theather-managment/theather-managment.component';
@Component({
  selector: 'app-client-managment',
  templateUrl: './client-managment.component.html',
  styleUrls: ['./client-managment.component.css'],
})
export class ClientManagmentComponent implements OnInit {
  deletingUser: boolean = false;
  modifiyingUser: boolean = false;
  addingUser: boolean = false;
  get: boolean = false;

  users: any[] = [];
  birthdate: Date = new Date();
  firstName: string = '';
  idCard: string = '';
  lastName: string = '';
  middleName: string = '';
  password: string = '';
  phoneNum: string = '';
  secondLastName: string = '';
  username: string = '';

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<TheatherManagmentComponent>,
    public backend: BackendService
  ) {}

  ngOnInit(): void {
    let clients: any[] = [];
    this.backend.get_request('Admin/Client', null).subscribe((result) => {
      //console.log(result);
      clients = result;
      clients.forEach((client) => {
        this.users.push(client);
      });
    });
  }
  selectUser(event: any) {
    //console.log(event);

    this.birthdate = event.birthdate;
    this.firstName = event.firstName;
    this.idCard = event.idCard;
    this.lastName = event.lastName;
    this.middleName = event.middleName;
    this.password = event.password;
    this.phoneNum = event.phoneNum;
    this.secondLastName = event.secondLastName;
    this.username = event.username;
  }
  submitModify() {
    if (
      this.firstName !== '' &&
      this.lastName !== '' &&
      this.middleName !== '' &&
      this.password !== '' &&
      this.phoneNum !== '' &&
      this.secondLastName !== '' &&
      this.username !== ''
    ) {
      let data = {
        birthdate: this.birthdate,
        firstName: this.firstName,
        idCard: this.idCard,
        lastName: this.lastName,
        middleName: this.middleName,
        password: this.password,
        phoneNum: this.phoneNum,
        secondLastName: this.secondLastName,
        username: this.username,
      };
      this.backend.put_request('Admin/Client', data).subscribe((responde) => {
        this.swal.showSuccess(
          'Empleado modificado',
          'Empleado modificado con ??xito'
        );
      });
    } else {
      this.swal.showError(
        'Error al modificar al empleado',
        'Los datos ingresados son insuficientes o el empleado no existe en nuestra base de datos'
      );
    }
  }

  submitAdition() {
    if (
      this.birthdate !== undefined &&
      this.firstName !== '' &&
      this.idCard !== '' &&
      this.lastName !== '' &&
      this.middleName !== '' &&
      this.password !== '' &&
      this.phoneNum !== '' &&
      this.secondLastName !== '' &&
      this.username !== ''
    ) {
      let data = {
        birthdate: this.birthdate,
        firstName: this.firstName,
        idCard: this.idCard,
        lastName: this.lastName,
        middleName: this.middleName,
        password: this.password,
        phoneNum: this.phoneNum,
        secondLastName: this.secondLastName,
        username: this.username,
      };
      this.backend.post_request('Admin/Client', data).subscribe((responde) => {
        this.swal.showSuccess('Usuario Creado', 'Usuario Creado con ??xito');
      });
    } else {
      this.swal.showError(
        'Error al crear al empleado',
        'Los datos ingresados son insuficientes o el empleado no existe en nuestra base de datos'
      );
    }
  }

  deleteUser() {
    this.backend
      .delete_request('Admin/Client', {
        id: this.idCard,
        username: this.username,
      })
      .subscribe((result) => {
        this.swal.showSuccess(
          'Pel??cula eliminada',
          'Pel??cula eliminada con ??xito'
        );
      });
  }
  close() {
    this.dialogRef.close();
  }
  selectDate(event: any) {
    this.birthdate = event._selected;
    //console.log(this.birthdate);
  }
}
