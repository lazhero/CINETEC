import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SwalService } from 'src/app/services/swalService';

@Component({
  selector: 'app-theather-managment',
  templateUrl: './theather-managment.component.html',
  styleUrls: ['./theather-managment.component.css'],
})
export class TheatherManagmentComponent implements OnInit {
  creatingTheather: boolean = false;
  modifiyingTheather: boolean = false;

  theaters: any[] = [
    { name: 'sucursal1', location: 'Santa Ana', roomNumber: '32' },
    { name: 'sucursal2', location: 'Alajuela', roomNumber: '12' },
    { name: 'sucursal3', location: 'Heredia', roomNumber: '4' },
  ];

  constructor(
    public swal: SwalService,
    public dialogRef: MatDialogRef<TheatherManagmentComponent>,
    public formBuilder: FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
  ngOnInit(): void {}

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
      this.swal.showSuccess(
        'Sucursal agregada',
        'la sucursal fue agregada con éxito'
      );
      console.log(this.sucursal + ' ' + this.location + ' ' + this.roomNumber);
    } else
      this.swal.showError(
        'Erro al agregar la sucursal',
        'Algunos valores estan vacios o incompletos'
      );
  }
  submitModify() {
    console.log(this.sucursal + ' ' + this.location + ' ' + this.roomNumber);
  }
}
