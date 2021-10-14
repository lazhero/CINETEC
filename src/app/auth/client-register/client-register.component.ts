import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-client-register',
  templateUrl: './client-register.component.html',
  styleUrls: ['./client-register.component.css'],
})
export class ClientRegisterComponent implements OnInit {
  form: FormGroup;

  constructor(
    private router: Router,
    public backend: BackendService,
    private swal: SwalService,
    private formBuilder: FormBuilder
  ) {
    this.form = this.formBuilder.group({
      name: '',
      lastName: '',
      userName: '',
      Password: '',
      Address: '',
      birthDate: Date.now(),
      phoneNumb: '',
      passwordConfirmation: '',
      idCard: '',
    });
  }
  ngOnInit(): void {}

  createClient(): void {
    const data = {
      idCard: 13331,
      phoneNum: 0,
      firstName: 'TEST',
      middleName: 'TEST',
      lastName: 'TEST',
      secondLastName: 'TEST',
      username: '1333e2',
      password: 'TEST',
      birthdate: '2021-10-07T18:46:31.254Z',
      clientInvoices: [],
      projectionClients: [],
    };
    this.backend.post_request('Admin/Client', data).subscribe(
      (data) => {
        this.swal.showSuccess('Bienvenido', 'Usuario registrado con éxito');
        this.router.navigateByUrl('pages');
      },
      (error) => {
        this.swal.showError(
          'Error',
          'Ya existe un usuario con la misma identificación'
        );
        console.log(error);
      }
    );
  }
}