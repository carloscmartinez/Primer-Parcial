import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LiquidacionRegistroComponent } from './liquidacion/liquidacion-registro/liquidacion-registro.component';
import { LiquidacionConsultaComponent } from './liquidacion/liquidacion-consulta/liquidacion-consulta.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    {
    path: 'liquidacionConsulta',
    component: LiquidacionConsultaComponent
    },
    {
      path: 'liquidacionRegistro',
      component: LiquidacionRegistroComponent
    }
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
