import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/services/backend-service.service';
import { SwalService } from 'src/app/services/swalService';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(
    private router: Router,
    public backend: BackendService,
    private swal: SwalService,
    private formBuilder: FormBuilder
  ) {
    this.form = this.formBuilder.group({
      Password: '',
      Address: '',
    });
  }
  form: FormGroup;
  ngOnInit(): void {}
  devlogin() {
    this.form.value.Address = 'Luisito354';
    this.form.value.Password = 'satanas1234';
    this.login();
  }
  login() {
    const info = {
      username: this.form.value.Address,
      password: this.form.value.Password,
    };

    this.backend.post_request('Login', info).subscribe((user) => {
      //console.log(user);

      if (user === null || user == undefined || user == '') {
        this.swal.showError(
          'Oops',
          'El usuario no se encuentra en la base de datos '
        );
        return;
      } else {
        localStorage.setItem('user', JSON.stringify(user));
        this.router.navigateByUrl('pages');
      }
    });
  }
  register() {
    this.router.navigateByUrl('auth/clientRegister');
  }
}
