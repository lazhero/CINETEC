import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { TheatherManagmentComponent } from '../theather-managment/theather-managment.component';
@Component({
  selector: 'app-employee-managment',
  templateUrl: './employee-managment.component.html',
  styleUrls: ['./employee-managment.component.css'],
})
export class EmployeeManagmentComponent implements OnInit {
  deletingEmployee: boolean = false;
  modifiyingEmployee: boolean = false;
  addingEmployee: boolean = false;
  get: boolean = false;
  employees: any[] = [];

  birthdate: string = '';
  cinemaName: string = '';
  firstDateWorking: string = '';
  firstName: string = '';
  idCard: string = '';
  lastName: string = '';
  middleName: string = '';
  password: string = '';
  phoneNum: string = '';
  role: string = '';
  roleId: string = '';
  secondLastName: string = '';
  username: string = '';

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<TheatherManagmentComponent>,
    public backend: BackendService
  ) {}

  ngOnInit(): void {
    let employeesList: any[] = [];
    this.backend.get_request('Admin/Employee', null).subscribe((result) => {
      //console.log(result);
      employeesList = result;
      employeesList.forEach((employee) => {
        this.employees.push(employee);
      });
    });
  }
  selectUser(event: any) {
    this.birthdate = event.birthdate;
    this.cinemaName = event.cinemaName;
    this.firstDateWorking = event.firstDateWorking;
    this.firstName = event.firstName;
    this.idCard = event.idCard;
    this.lastName = event.lastName;
    this.middleName = event.middleName;
    this.password = event.password;
    this.phoneNum = event.phoneNum;
    this.role = event.role;
    this.roleId = event.roleId;
    this.secondLastName = event.secondLastName;
    this.username = event.username;
    //console.log(event);
  }
  submitModify() {
    if (
      this.birthdate !== '' &&
      this.cinemaName !== '' &&
      this.firstDateWorking !== '' &&
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
        cinemaName: this.cinemaName,
        firstDateWorking: this.firstDateWorking,
        firstName: this.firstName,
        lastName: this.lastName,
        middleName: this.middleName,
        password: this.password,
        phoneNum: this.phoneNum,
        roleId: 1,
        idCard: this.idCard,
        secondLastName: this.secondLastName,
        username: this.username,
      };
      //console.log(data);

      this.backend.put_request('Admin/Employee', data).subscribe((responde) => {
        this.swal.showSuccess(
          'Empleado modificado',
          'Empleado modificado con éxito'
        );
      });
    } else {
      this.swal.showError(
        'Error al modificar al empleado',
        'Los datos ingresados son insuficientes o el empleado no existe en nuestra base de datos'
      );
    }
  }

  selectSucursal($event: string) {
    this.cinemaName = $event;
  }

  submitAdition() {
    if (
      this.birthdate !== '' &&
      this.cinemaName !== '' &&
      this.firstDateWorking !== '' &&
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
        birthdate: new Date(this.birthdate),
        cinemaName: this.cinemaName,
        firstDateWorking: new Date(this.firstDateWorking),
        firstName: this.firstName,
        idCard: this.idCard,
        lastName: this.lastName,
        middleName: this.middleName,
        password: this.password,
        phoneNum: this.phoneNum,
        roleId: 1,
        secondLastName: this.secondLastName,
        username: this.username,
      };
      //console.log(data);

      this.backend
        .post_request('Admin/Employee', data)
        .subscribe((responde) => {
          this.swal.showSuccess('Empleado Creado', 'Empleado Creado con éxito');
        });
    } else {
      this.swal.showError(
        'Error al modificar al empleado',
        'Los datos ingresados son insuficientes o el empleado no existe en nuestra base de datos'
      );
    }
  }

  deleteUser() {
    const data = {
      username: this.username,
      id: this.idCard,
    };
    //console.log(data);

    this.backend.delete_request('Admin/Employee', data).subscribe((result) => {
      this.swal.showSuccess(
        'Empleado eliminado',
        'Empleado eliminado con éxito'
      );
    });
  }
  close() {
    this.dialogRef.close();
  }
}
