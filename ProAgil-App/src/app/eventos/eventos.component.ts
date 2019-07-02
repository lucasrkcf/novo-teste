import { Component, OnInit } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

// tslint:disable-next-line: variable-name
  _filtroLista: string;
  get filtroLista(): string {
    return this._filtroLista;

  }
  set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }
  eventosFiltrados: Evento[];
  eventos: Evento[];
  imagemLargura = 50;
  imagemMargem = 2;
  mostrarImagem = false;


  constructor(private eventoService: EventoService ) { }

  ngOnInit() {
    this.getEventos();
  }

  filtrarEventos(filtratPor: string): Evento[] {
    filtratPor = filtratPor.toLocaleLowerCase();
    return this.eventos.filter(
      evento => evento.tema.toLocaleLowerCase().indexOf(filtratPor) !== -1

    );
  }
  alternarImgem() {
    this.mostrarImagem = !this.mostrarImagem;
  }
getEventos() {
  this.eventoService.getAllEvento().subscribe(
    (_eventos: Evento[]) => {
    this.eventos = _eventos;
    this.eventosFiltrados = this.eventos;
    console.log(_eventos);
}, error => {
  console.log(error);
});
}
}
