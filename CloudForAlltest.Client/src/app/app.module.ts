import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { NavbarComponent } from 'src/app/components/navbar/navbar.component';
import { PreventaListComponent } from './components/preventa/preventa-list/preventa-list.component';
import { PreventaFormComponent } from './components/preventa/preventa-form/preventa-form.component';
import { FacturaService } from './services/factura.service';
import { PreventaService } from './services/preventa.service';
import { ProductoService } from './services/producto.service';
import { UsuarioService } from './services/usuario.service';
import { ProductoListComponent } from './components/producto/producto-list/producto-list.component';
import { ProductoFormComponent } from './components/producto/producto-form/producto-form.component';
import { VentaListComponent } from './components/venta/venta-list/venta-list.component';
import { VentaFormComponent } from './components/venta/venta-form/venta-form.component';


@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PreventaListComponent,
    PreventaFormComponent,
    ProductoListComponent,
    ProductoFormComponent,
    VentaListComponent,
    VentaFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    FacturaService,
    PreventaService,
    ProductoService,
    UsuarioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
