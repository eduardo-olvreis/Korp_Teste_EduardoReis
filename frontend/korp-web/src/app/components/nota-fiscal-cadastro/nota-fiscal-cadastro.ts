import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router } from '@angular/router';
import { NotaFiscalService } from '../../services/nota-fiscal';
import { ProdutoService } from '../../services/produto';

@Component({
  selector: 'app-nota-fiscal-cadastro',
  templateUrl: './nota-fiscal-cadastro.html',
  standalone: false
})
export class NotaFiscalCadastro implements OnInit {
  produtos: any[] = [];
  nota = {
    numeroSequencial: Math.floor(1000 + Math.random() * 9000),
    status: 'Aberta',
    itens: [
      { produtoId: null, quantidade: 1 }
    ]
  };

  constructor(
    private notaService: NotaFiscalService,
    private produtoService: ProdutoService,
    private router: Router,
    private cdRef: ChangeDetectorRef
  ) { }

  ngOnInit(): void {
    this.produtoService.getProdutos().subscribe({
      next: (dados) => {
        this.produtos = dados;
        this.cdRef.detectChanges();
      },
      error: (err) => console.error('Erro ao carregar produtos:', err)
    });
  }

  salvar(): void {
    if (!this.nota.itens[0].produtoId) {
      alert('Selecione um produto!');
      return;
    }

  this.notaService.criarNota(this.nota as any).subscribe({
    next: () => {
      alert('Nota Fiscal emitida com sucesso!');
      this.router.navigate(['/notas']);
    },
    error: (err) => {
      console.error(err);
      alert('Erro ao emitir nota.');
    }
  });
}}