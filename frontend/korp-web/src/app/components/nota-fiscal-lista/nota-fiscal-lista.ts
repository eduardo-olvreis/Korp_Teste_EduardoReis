import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { NotaFiscalService } from '../../services/nota-fiscal';
import { NotaFiscal } from '../../models/nota-fiscal.model';

@Component({
  selector: 'app-nota-fiscal-lista',
  templateUrl: './nota-fiscal-lista.html',
  standalone: false
})
export class NotaFiscalLista implements OnInit {
  notas: NotaFiscal[] = [];

  constructor(
    private notaService: NotaFiscalService,
    private cdRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.notaService.getNotas().subscribe({
      next: (dados) => {
        this.notas = dados;
        this.cdRef.detectChanges();
      }
    });
  }
}