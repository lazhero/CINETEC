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

  employees: any[] = [];


 
  birthdate:            string = '';
  cinemaName:           string = '';
  firstDateWorking:     string = '';
  firstName:            string = '';
  idCard:               string = '';
  lastName:             string = '';
  middleName:           string = '';
  password:             string = '';
  phoneNum:             string = '';
  role:                 string = '';
  roleId:               string = '';
  secondLastName:       string = '';
  username:             string = '';



  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<TheatherManagmentComponent>,
    public backend: BackendService
  ) {}

  ngOnInit(): void {
    let employeesList: any[] = [];
    this.backend.get_request("Admin/Employee",null)
    .subscribe(result=>{
      console.log(result);
      employeesList = result;
      employeesList.forEach(employee=>{
        this.employees.push(employee);
      })
    })
    
    
  }
  selectUser(event: any) {

    this.birthdate             = event.birthdate;
    this.cinemaName            = event.cinemaName;
    this.firstDateWorking      = event.firstDateWorking;
    this.firstName             = event.firstName;
    this.idCard                = event.idCard;
    this.lastName              = event.lastName;
    this.middleName            = event.middleName;
    this.password              = event.password;
    this.phoneNum              = event.phoneNum;
    this.role                  = event.role;
    this.roleId                = event.roleId;
    this.secondLastName        = event.secondLastName;
    this.username              = event.username;
  }
  submitModify() {
    if (
      this.birthdate             !== '' &&
      this.cinemaName            !== '' &&
      this.firstDateWorking      !== '' &&
      this.firstName             !== '' &&
      this.idCard                !== '' &&
      this.lastName              !== '' &&
      this.middleName            !== '' &&
      this.password              !== '' &&
      this.phoneNum              !== '' &&
      this.role                  !== '' &&
      this.roleId                !== '' &&
      this.secondLastName        !== '' &&
      this.username              !== '' 
    ) {
      this.swal.showSuccess(
        'Empleado modificado',
        'Empleado modificado con éxito'
      );
    } else {
      this.swal.showError(
        'Error al modificar al empleado',
        'Los datos ingresados son insuficientes o el empleado no existe en nuestra base de datos'
      );
    }
  }

  deleteUser() {
    for (let i = 0; i < this.employees.length; i++) {
      if (this.employees[i].idCard === this.idCard) {
        this.employees.splice(i, 1);
        this.swal.showSuccess(
          'Empleado eliminado',
          'Empleado eliminado con éxito'
        );
        return;
      }
    }
    this.swal.showError(
      'Error al eliminar empleado',
      'El empleados no se encuentra en la base de datos'
    );
  }
  close() {
    this.dialogRef.close();
  }
}
