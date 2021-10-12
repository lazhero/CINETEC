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

  getRandomInt(min: number, max: number) {
    return Math.floor(Math.random() * (max - min)) + min;
  }

  createClient(): void {
    const rand = this.getRandomInt(0, 100000000);

    let data = {
      idCard: rand,
      phoneNum: 0,
      firstName: rand.toString(),
      middleName: 'TEST',
      lastName: 'TEST',
      secondLastName: 'TEST',
      username: rand.toString(),
      password: 'TEST',
      birthdate: new Date(),
      clientInvoices: [],
      projectionClients: [],
    };
    console.log(data);

    this.backend.post_request('Admin/Client', data).subscribe(
      (value) => {
        console.log(data);

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
