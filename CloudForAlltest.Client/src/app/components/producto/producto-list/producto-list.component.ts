import { Component, OnInit, OnDestroy } from '@angular/core';
import { ProductoService } from 'src/app/services/producto.service';
import { Subscription } from 'rxjs';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-producto-list',
  templateUrl: './producto-list.component.html',
  styleUrls: ['./producto-list.component.css']
})
export class ProductoListComponent implements OnInit, OnDestroy {
  messageSubscription: Subscription;
  productos: [];
  productoId: string;
  formularioVisible = false;
  codeMessage = {
    delete: 1
  };

  constructor(private productoService: ProductoService, private message: MessageService) { }

  ngOnInit(): void {
    this.getProductos();

    this.messageSubscription = this.message.getActionConfirm().subscribe(
      res => {
        switch (res) {
          case this.codeMessage.delete:
            this.borraProducto();
            break;
          default:
            break;
        }
      }
    );
  }

  ngOnDestroy() {
    this.messageSubscription.unsubscribe();
  }

  getProductos(): void {
    this.productoService.getProductos().subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.productos = res.response;
        } else {
          console.error(res.errorResponse);
        }
      },
      error => console.error(error)
    );
  }

  procesarRefresco() {
    this.getProductos();
    this.mostrarFormulario(false);
  }

  editar(id: string) {
    this.productoId = id;
    this.mostrarFormulario(true);
  }

  mostrarFormulario(value: boolean) {
    this.formularioVisible = value;
  }

  confirmaBorrado(id: string) {
    this.productoId = id;
    this.message.showConfirm('Desea borrar el producto?', 'Eliminar', this.codeMessage.delete);
  }

  borraProducto() {
    this.productoService.deleteProducto(this.productoId).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.getProductos();
          this.message.showMessage('success', 'Se ha eliminado exitosamente el producto');
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

}
