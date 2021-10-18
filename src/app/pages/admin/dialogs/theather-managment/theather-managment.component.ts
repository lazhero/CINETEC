import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-theather-managment',
  templateUrl: './theather-managment.component.html',
  styleUrls: ['./theather-managment.component.css'],
})
export class TheatherManagmentComponent implements OnInit {
  creatingTheather: boolean = false;
  modifiyingTheather: boolean = false;
  deletingMovie: boolean = false;
  get: boolean = false;
  theaters: any[] = [];

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<TheatherManagmentComponent>,
    public formBuilder: FormBuilder,
    public backed: BackendService,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
  ngOnInit(): void {
    this.backed.get_request('Admin/Sucursales', null).subscribe((value) => {
      this.theaters = value;
      //console.log(value);
    });
  }

  sucursal: string = '';
  location: string = '';
  roomNumber: number = 0;

  selectSucursal(event: any) {
    let sucursal;
    for (let i = 0; i < this.theaters.length; i++) {
      if (this.theaters[i].name === event) {
        sucursal = this.theaters[i];
        break;
      }
    }

    this.sucursal = sucursal.name;
    this.location = sucursal.location;
    this.roomNumber = sucursal.roomNumber;
  }

  close() {
    this.dialogRef.close();
  }
  create() {
    if (this.sucursal !== '' && this.location !== '' && this.roomNumber >= 0) {
      const data = {
        name: this.sucursal,
        location: this.location,
        employees: [],
        rooms: [],
      };
      this.backed.post_request('Admin/Sucursales', data).subscribe((value) => {
        this.swal.showSuccess(
          'Sucursal agregada',
          'la sucursal fue agregada con éxito'
        );
      });
    } else
      this.swal.showError(
        'Erro al agregar la sucursal',
        'Algunos valores estan vacios o incompletos'
      );
  }
  submitModify() {
    const data = {
      name: this.sucursal,
      location: this.location,
      employees: [],
      rooms: [],
    };
    this.backed.put_request('Admin/Sucursales', data).subscribe((value) => {
      //console.log(value);
    });
  }

  submitDelete() {
    const data = {
      new_data: this.sucursal,
    };
    //console.log(data);
    this.backed.delete_request('Admin/Sucursales', data).subscribe((value) => {
      this.swal.showSuccess('Acción ejecutada', 'Sucursal eliminada con éxito');
    });
  }
}
