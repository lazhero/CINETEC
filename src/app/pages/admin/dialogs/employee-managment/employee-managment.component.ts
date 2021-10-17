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
      this.lastName              !== '' &&
      this.middleName            !== '' &&
      this.password              !== '' &&
      this.phoneNum              !== '' &&
      this.secondLastName        !== '' &&
      this.username              !== '' 
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
        secondLastName: this.secondLastName,
        username:this.username          
      }
      this.backend.post_request("Admin/Employee",data)
      .subscribe(responde=>{
        this.swal.showSuccess(
          'Empleado modificado',
          'Empleado modificado con éxito'
        );
      })
    } else {
      this.swal.showError(
        'Error al modificar al empleado',
        'Los datos ingresados son insuficientes o el empleado no existe en nuestra base de datos'
      );
    }
  }

  selectSucursal($event: any) {
    this.cinemaName = $event;
    console.log(this.cinemaName);

    this.backend
      .get_request('Admin/Sucursales', { cinema_name: this.cinemaName })
      .subscribe((value) => {
        this.cinemaName = value;
      });
  }

  submitAdition() {
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
      this.secondLastName        !== '' &&
      this.username              !== '' 
    ) {
      let data = {
        birthdate: this.birthdate,
        cinemaName: this.cinemaName,
        firstDateWorking: this.firstDateWorking,
        firstName: this.firstName,
        idCard: this.idCard,
        lastName: this.lastName,
        middleName: this.middleName,
        password: this.password,
        phoneNum: this.phoneNum,
        roleId:1,
        secondLastName: this.secondLastName,
        username:this.username          
      }
      this.backend.post_request("Admin/Employee",data)
      .subscribe(responde=>{
        this.swal.showSuccess(
          'Empleado modificado',
          'Empleado modificado con éxito'
        );
      })
    } else {
      this.swal.showError(
        'Error al modificar al empleado',
        'Los datos ingresados son insuficientes o el empleado no existe en nuestra base de datos'
      );
    }
  }

  deleteUser() {
    
    
    this.backend.delete_request("Admin/Movies",
                                {movie_org_name: this.idCard})
        .subscribe(result=>{
          this.swal.showSuccess(
            'Película eliminada',
            'Película eliminada con éxito'
          );

        })
    
  }
  close() {
    this.dialogRef.close();
  }
}
