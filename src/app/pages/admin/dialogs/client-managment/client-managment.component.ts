import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
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
  get: boolean = false;
  users: any[] = [
    {
      Id_card: 'abc',
      Birthday: '9/9/2021',
      Phone_Num: '6025000',
      First_Name: 'Pedro',
      Middle_Name: 'Josue',
      Last_Name: 'Gomez',
      Second_LastName: 'Jimenez',
      Username: 'JGOMJI',
      Password: '1234',
    },
    {
      Id_card: 'abcde',
      Birthday: '9/9/2021',
      Phone_Num: '60898900',
      First_Name: 'Luis',
      Middle_Name: 'Andrey',
      Last_Name: 'Zuñiga',
      Second_LastName: 'Algo',
      Username: 'luicito',
      Password: '1234',
    },
    {
      Id_card: 'abcdef',
      Birthday: '9/9/2021',
      Phone_Num: '8887000',
      First_Name: 'Adrian',
      Middle_Name: 'Josue',
      Last_Name: 'González',
      Second_LastName: 'Jimenez',
      Username: 'adrian',
      Password: '1234',
    },
  ];

  Id_card: string = '';
  Birthday: any = new Date(new Date().getTime() - 3888000000);
  Phone_Num: string = '';
  First_Name: string = '';
  Middle_Name: string = '';
  Last_Name: string = '';
  Second_LastName: string = '';
  Username: string = '';
  Password: string = '';
  selected: boolean = false;

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<TheatherManagmentComponent>
  ) {}

  ngOnInit(): void {}
  selectUser(event: any) {
    this.Id_card = event.Id_card;
    this.Birthday = new Date(new Date().getTime() - 3888000000);
    this.Phone_Num = event.Phone_Num;
    this.First_Name = event.First_Name;
    this.Middle_Name = event.Middle_Name;
    this.Last_Name = event.Last_Name;
    this.Second_LastName = event.Second_LastName;
    this.Username = event.Username;
    this.Password = event.Password;
  }
  submitModify() {
    if (
      this.Id_card !== '' &&
      this.Birthday !== undefined &&
      this.Phone_Num !== '' &&
      this.First_Name !== '' &&
      this.Middle_Name !== '' &&
      this.Last_Name !== '' &&
      this.Second_LastName !== '' &&
      this.Username !== '' &&
      this.Password
    ) {
      this.swal.showSuccess(
        'Usuario modificado',
        'Usuario modificado con éxito'
      );
    } else {
      this.swal.showError(
        'Error al modificar el usuario',
        'Los datos ingresados son insuficientes o el usuario no existe en nuestra base de datos'
      );
    }
  }

  deleteUser() {
    for (let i = 0; i < this.users.length; i++) {
      if (this.users[i].Id_card === this.Id_card) {
        this.users.splice(i, 1);
        this.swal.showSuccess(
          'Usuario eliminado',
          'Usuario eliminado con éxito'
        );
        return;
      }
    }
    this.swal.showError(
      'Error al eliminar usuario',
      'El usuario no se encuentra en la base de datos'
    );
  }
  close() {
    this.dialogRef.close();
  }
}
