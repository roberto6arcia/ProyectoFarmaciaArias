import { Component, OnInit } from '@angular/core';
import { User } from '../../seguridad/user';
import { UserService } from 'src/app/services/user.service';
import { FormBuilder, Validators, AbstractControl, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AlertModalComponent } from '../../@base/alert-modal/alert-modal.component';

@Component({
  selector: 'app-usuario-registro-reactivo',
  templateUrl: './usuario-registro-reactivo.component.html',
  styleUrls: ['./usuario-registro-reactivo.component.css']
})
export class UsuarioRegistroReactivoComponent implements OnInit {

  user: User;
  formGroup: FormGroup;
  submitted = false;
  constructor(private userService: UserService, private formBuilder: FormBuilder, private modalService: NgbModal) { }

  ngOnInit() {
    this.buildForm();
  }

  private buildForm() {
    this.user = new User();
    this.user.userName = '';
    this.user.password = '';
    this.user.estado = '';
    this.user.firstName = '';
    this.user.lastName = '';
    this.user.idUser = '';
    this.user.email = '';
    this.user.mobilePhone = '';
    this.user.role = '';
    
    this.formGroup = this.formBuilder.group({
      userName: [this.user.userName, Validators.required],
      password: [this.user.password, Validators.required],
      estado: [this.user.estado, Validators.required],
      firstName: [this.user.firstName, Validators.required],
      lastName: [this.user.lastName, Validators.required],
      idUser: [this.user.idUser, Validators.required],
      email: [this.user.email, Validators.required],
      mobilePhone: [this.user.mobilePhone, Validators.required],
      role: [this.user.role, Validators.required ]

    });
  }

  get control() {
    return this.formGroup.controls;
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.formGroup.invalid) {
      return;
    }
    this.add();
  }

  add() {
    this.user = this.formGroup.value;
    this.userService.post(this.user).subscribe(p => {
      if (p != null) {

        const messageBox = this.modalService.open(AlertModalComponent)
        messageBox.componentInstance.title = "Resultado Operación";
        messageBox.componentInstance.message = 'User creado';

        this.user = p;
      }
    });

  }

}
