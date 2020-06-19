import { NgModule, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ProductoConsultaComponent } from './Farmacia/producto-consulta/producto-consulta.component';
import { ProductoRegistroReactivoComponent } from './Farmacia/producto-registro-reactivo/producto-registro-reactivo.component';
import { ProductoEditarComponent } from './Farmacia/producto-editar/producto-editar.component';
import { LoginComponent } from './Farmacia/login/login.component';
import { AcercaDeComponent } from './Farmacia/acerca-de/acerca-de.component';
import { VentaRegistroReactivoComponent } from './Farmacia/venta-registro-reactivo/venta-registro-reactivo.component';
import { VentaConsultaComponent } from './Farmacia/venta-consulta/venta-consulta.component';
import { AuthGuard } from './services/auth.guard';

import { UsuarioConsultaComponent } from './Farmacia/usuario-consulta/usuario-consulta.component';
import { UsuarioRegistroReactivoComponent } from './Farmacia/usuario-registro-reactivo/usuario-registro-reactivo.component';

const routes: Routes = [
  {path: 'productoConsulta', component: ProductoConsultaComponent,  canActivate: [AuthGuard], data: { roles: ["Administrador","Vendedor"]}},
  {path: 'productoRegistroreactivo',component: ProductoRegistroReactivoComponent,  canActivate: [AuthGuard], data: { roles: ["Administrador","Vendedor"]}},
  
  {path: 'productoEditar/:codigoP',component: ProductoEditarComponent,  canActivate: [AuthGuard], data: { roles: ["Administrador"]}},
  {path: 'acercaDeFarmacia',component: AcercaDeComponent},

  {path: 'ventaRegistroreactivo',component: VentaRegistroReactivoComponent,  canActivate: [AuthGuard], data: { roles: ["Administrador","Vendedor"]}},
  {path: 'ventaConsulta', component: VentaConsultaComponent,  canActivate: [AuthGuard], data: { roles: ["Administrador","Vendedor"]}},

  {path: 'login', component: LoginComponent},
  
  {path: 'userRegistroreactivo',component: UsuarioRegistroReactivoComponent,  canActivate: [AuthGuard], data: { roles: ["Administrador"]}},
  {path: 'userConsulta', component: UsuarioConsultaComponent,  canActivate: [AuthGuard], data: { roles: ["Administrador"]}},
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
