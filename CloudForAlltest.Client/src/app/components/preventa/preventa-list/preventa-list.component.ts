import { Component, OnInit, OnDestroy } from '@angular/core';
import { PreventaService } from 'src/app/services/preventa.service';
import { MessageService } from 'src/app/services/message.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-preventa-list',
  templateUrl: './preventa-list.component.html',
  styleUrls: ['./preventa-list.component.css']
})
export class PreventaListComponent implements OnInit, OnDestroy {
  messageSubscription: Subscription;
  preventas: [];
  preventaId: string;
  formularioVisible = false;
  codeMessage = {
    delete: 1
  };

  constructor(private preventaService: PreventaService, private message: MessageService) { }

  ngOnInit(): void {
    this.getPreventas();

    this.messageSubscription = this.message.getActionConfirm().subscribe(
      res => {
        switch (res) {
          case this.codeMessage.delete:
            this.borraPreventa();
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

  getPreventas(): void {
    this.preventaService.getPreventas().subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.preventas = res.response;
        } else {
          console.error(res.errorResponse);
        }
      },
      error => console.error(error)
    );
  }

  procesarRefresco() {
    this.getPreventas();
    this.mostrarFormulario(false);
  }

  editar(id: string) {
    this.preventaId = id;
    this.mostrarFormulario(true);
  }

  mostrarFormulario(value: boolean) {
    this.formularioVisible = value;
  }

  confirmaBorrado(id: string) {
    this.preventaId = id;
    this.message.showConfirm('Desea borrar la preventa?', 'Eliminar', this.codeMessage.delete);
  }

  borraPreventa() {
    this.preventaService.deletePreventa(this.preventaId).subscribe(
      res => {
        if (res.httpResponse === 200) {
          this.getPreventas();
          this.preventaId = undefined;
          this.message.showMessage('success', 'Se ha eliminado exitosamente la preventa');
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
