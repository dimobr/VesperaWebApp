import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageContainerComponent } from './homepage/homepage-container/homepage-container.component';
import { HeaderComponent } from './homepage/header/header.component';
import { FooterComponent } from './homepage/footer/footer.component';

//const routes: Routes = [];

const routes: Routes = [
  { path: '', component: HeaderComponent },
  { path: 'main-content', component: HomepageContainerComponent },
  { path: 'footer', component: FooterComponent },
  { path: '', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
