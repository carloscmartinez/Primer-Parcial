import { Component, OnInit } from '@angular/core';
import { Liquidacion } from '../models/liquidacion';
import { LiquidacionService } from 'src/app/services/liquidacion.service';

@Component({
  selector: 'app-liquidacion-registro',
  templateUrl: './liquidacion-registro.component.html',
  styleUrls: ['./liquidacion-registro.component.css']
})
export class LiquidacionRegistroComponent implements OnInit {

  liquidacion: Liquidacion;
  constructor(private liquidacionService: LiquidacionService) { }

  ngOnInit() {
    this.liquidacion=new Liquidacion();
  }

  add() {
    this.liquidacionService.post(this.liquidacion).subscribe(p => {
      if (p != null) {
        alert('liquidacion registrada!');
        this.liquidacion = p;
      }
    });
  }


}
