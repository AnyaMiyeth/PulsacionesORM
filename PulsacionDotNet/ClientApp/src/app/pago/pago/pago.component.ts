import { Component, OnInit } from '@angular/core';
import { Pago } from '../pago';
import { PagoService } from '../pago.service';

@Component({
  selector: 'app-pago',
  templateUrl: './pago.component.html',
  styleUrls: ['./pago.component.css']
})
export class PagoComponent implements OnInit {

  pago: Pago;
  constructor(private pagoservice: PagoService) {
    this.pago = new Pago();
  }

  ngOnInit() {

  }
  add() {
    alert("hOLA");
    this.pagoservice.post(this.pago).subscribe(p => { this.pago = p }, error => console.log("Eror" + error));
  }

}
