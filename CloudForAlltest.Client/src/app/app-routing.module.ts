import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PreventaListComponent } from './components/preventa/preventa-list/preventa-list.component';
import { ProductoListComponent } from './components/producto/producto-list/producto-list.component';
import { VentaListComponent } from './components/venta/venta-list/venta-list.component';


const routes: Routes = [
  { path: 'preventa', component: PreventaListComponent},
  { path: 'producto', component: ProductoListComponent},
  { path: 'venta', component: VentaListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
