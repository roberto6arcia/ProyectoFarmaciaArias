import { Component, OnInit } from '@angular/core';
import { User } from '../../seguridad/user';
import { UserService } from 'src/app/services/user.service';
import { SignalRService } from '../../services/signal-r.service';

@Component({
  selector: 'app-usuario-consulta',
  templateUrl: './usuario-consulta.component.html',
  styleUrls: ['./usuario-consulta.component.css']
})
export class UsuarioConsultaComponent implements OnInit {

  searchText:string;
  users: User[];
  constructor(private userService: UserService, private signalRService: SignalRService) { }

  ngOnInit() {
    this.userService.get().subscribe(result => {
      this.users = result;
    });

    ///Se suscribe al servicio de signal r y cuando se regustr una nueva user se agregará el registro nuevo al array personas
    this.signalRService.userReceived.subscribe((user: User) => {
      this.users.push(user);
    });

  }

}
