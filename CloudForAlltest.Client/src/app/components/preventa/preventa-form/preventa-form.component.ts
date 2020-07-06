import { Component, OnInit, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PreventaService } from 'src/app/services/preventa.service';
import { Preventa } from 'src/app/models/preventa';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-preventa-form',
  templateUrl: './preventa-form.component.html',
  styleUrls: ['./preventa-form.component.css']
})
export class PreventaFormComponent implements OnInit, OnChanges {
  @Input() preventaId: string;
  @Output() refrescar = new EventEmitter();
  @Output() cancelar = new EventEmitter();
  preventaForm: FormGroup;
  preventa: Preventa;
  textoBoton = 'Guardar';

  constructor(private fb: FormBuilder, private preventaService: PreventaService, private message: MessageService) { }

  ngOnInit(): void {
    this.createForm();
  }

  ngOnChanges() {
    if (this.preventaId) {
      this.obtenerPreventa();
      this.cambiarTextoBoton();
    }
  }

  createForm() {
    this.preventaForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      lugarDespacho: ['', Validators.required],
    });
  }

  cargarFormulario() {
    this.preventaForm.controls.email.setValue(this.preventa.email);
    this.preventaForm.controls.lugarDespacho.setValue(this.preventa.lugarDespacho);
  }

  obtenerPreventa() {
    this.preventaService.getPreventa(this.preventaId).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.preventa = res.response;
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

  mantenimientoPreventa() {
    this.preventa = this.preventaForm.value;

    if (this.preventaId) {
      this.preventa.preventaId = this.preventaId;
      this.actualizarPreventa();
    } else {
      this.crearPreventa();
    }
  }

  limpiarFormulario() {
    this.preventaForm.reset();
  }

  crearPreventa() {
    this.preventaService.createPreventa(this.preventa).subscribe(
      res => {
        if (res.httpResponse === 201) {
          this.refrescar.emit();
          this.message.showMessage('success', 'Se ha creado exitosamente la preventa');
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
    this.preventaService.updatePreventa(this.preventa).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.refrescar.emit();
          this.message.showMessage('success', 'Se ha creado exitosamente la preventa');
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
    this.textoBoton = this.preventaId ? 'Actualizar' : 'Nuevo';
  }

  procesoCancelar() {
    this.cancelar.emit();
  }
}
