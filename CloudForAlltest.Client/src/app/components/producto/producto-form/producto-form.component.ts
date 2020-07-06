import { Component, OnInit, Input, Output, OnChanges, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Producto } from 'src/app/models/producto';
import { ProductoService } from 'src/app/services/producto.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-producto-form',
  templateUrl: './producto-form.component.html',
  styleUrls: ['./producto-form.component.css']
})
export class ProductoFormComponent implements OnInit, OnChanges {
  @Input() productoId: string;
  @Output() refrescar = new EventEmitter();
  @Output() cancelar = new EventEmitter();
  productoForm: FormGroup;
  producto: Producto;
  textoBoton = 'Guardar';

  constructor(private fb: FormBuilder, private productoService: ProductoService, private message: MessageService) { }

  ngOnInit(): void {
    this.createForm();
  }

  ngOnChanges() {
    if (this.productoId) {
      this.obtenerProducto();
      this.cambiarTextoBoton();
    }
  }

  createForm() {
    this.productoForm = this.fb.group({
      nomProducto: ['', Validators.required],
      valorUnitario: [0, Validators.required],
    });
  }

  cargarFormulario() {
    this.productoForm.controls.nomProducto.setValue(this.producto.nomProducto);
    this.productoForm.controls.valorUnitario.setValue(this.producto.valorUnitario);
  }

  obtenerProducto() {
    this.productoService.getProducto(this.productoId).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.producto = res.response;
          this.cargarFormulario();
        } else {
          this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
          console.error(res.errorResponse);
        }
      },
      error => {
        console.error(error);
        this.message.showMessage('error', 'A ocurrido un error, consulte con el administrador');
      }
    );
  }

  mantenimientoProducto() {
    this.producto = this.productoForm.value;

    if (this.productoId) {
      this.producto.productoId = this.productoId;
      this.actualizarPreventa();
    } else {
      this.crearPreventa();
    }
  }

  limpiarFormulario() {
    this.productoForm.reset();
  }

  crearPreventa() {
    this.productoService.createProducto(this.producto).subscribe(
      res => {
        if (res.httpResponse === 201) {
          this.refrescar.emit();
          this.message.showMessage('success', 'Se ha creado exitosamente el producto');
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

  actualizarPreventa() {
    this.productoService.updateProducto(this.producto).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.refrescar.emit();
          this.message.showMessage('success', 'Se ha actualizado exitosamente el producto');
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

  cambiarTextoBoton() {
    this.textoBoton = this.productoId ? 'Actualizar' : 'Nuevo';
  }

  procesoCancelar() {
    this.cancelar.emit();
  }

}
