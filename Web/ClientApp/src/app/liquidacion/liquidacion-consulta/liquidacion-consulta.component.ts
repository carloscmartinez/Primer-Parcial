import { Component, OnInit } from '@angular/core';
import { Liquidacion } from '../models/liquidacion';
import { LiquidacionService } from 'src/app/services/liquidacion.service';

@Component({
  selector: 'app-liquidacion-consulta',
  templateUrl: './liquidacion-consulta.component.html',
  styleUrls: ['./liquidacion-consulta.component.css']
})
export class LiquidacionConsultaComponent implements OnInit {

  liquidaciones: Liquidacion[];
  constructor(private liquidacionService: LiquidacionService) { }

  ngOnInit() {
    this.liquidacionService.get().subscribe(result => {
      this.liquidaciones = result;
    });

  }

}
