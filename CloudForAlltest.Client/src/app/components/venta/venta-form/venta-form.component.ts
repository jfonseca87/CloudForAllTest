import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Factura } from 'src/app/models/factura';
import { ProductoService } from 'src/app/services/producto.service';
import { PreventaService } from 'src/app/services/preventa.service';
import { FacturaService } from 'src/app/services/factura.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-venta-form',
  templateUrl: './venta-form.component.html',
  styleUrls: ['./venta-form.component.css']
})
export class VentaFormComponent implements OnInit {
  @Output() refrescar = new EventEmitter();
  @Output() cancelar = new EventEmitter();
  ventaForm: FormGroup;
  factura: Factura;
  productos = [];
  preventas = [];

  constructor(private fb: FormBuilder,
              private productoService: ProductoService,
              private preventaService: PreventaService,
              private facturaService: FacturaService,
              private message: MessageService) { }

  ngOnInit(): void {
    this.createForm();
    this.getPreventas();
    this.getProductos();
  }

  createForm() {
    this.ventaForm = this.fb.group({
      productoId: ['', Validators.required],
      cantidadProducto: [0, Validators.required],
      preventaId: ['', Validators.required]
    });
  }

  getProductos() {
    this.productoService.getProductos().subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.productos = res.response;
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

  getPreventas() {
    this.preventaService.getPreventas().subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.preventas = res.response;
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

  createVenta() {
    this.factura = this.ventaForm.value;

    this.facturaService.createFactura(this.factura).subscribe(
      res => {
        if (res.httpResponse === 201) {
          this.refrescar.emit();
          this.message.showMessage('success', 'Se ha creado exitosamente la venta');
        } else {
          this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
          console.error(res.errorResponse);
        }
        this.limpiarFormulario();
      },
      error => {
        console.error(error);
        this.limpiarFormulario();
        this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
      }
    );
  }

  procesoCancelar() {
    this.cancelar.emit();
  }

  limpiarFormulario() {
    this.ventaForm.reset();
  }
}
