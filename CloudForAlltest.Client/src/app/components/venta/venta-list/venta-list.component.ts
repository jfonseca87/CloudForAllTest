import { Component, OnInit } from '@angular/core';
import { FacturaService } from 'src/app/services/factura.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-venta-list',
  templateUrl: './venta-list.component.html',
  styleUrls: ['./venta-list.component.css']
})
export class VentaListComponent implements OnInit {
  facturas = [];
  formularioVisible = false;

  constructor(private facturaService: FacturaService, private message: MessageService) { }

  ngOnInit(): void {
    this.getFacturas();
  }

  getFacturas() {
    this.facturaService.getFacturas().subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.facturas = res.response;
        } else {
          this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
          console.error(res.errorResponse);
        }
      },
      error => {
        this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
        console.error(error);
      }
    );
  }

  mostrarFormulario(value: boolean) {
    this.formularioVisible = value;
  }
}
