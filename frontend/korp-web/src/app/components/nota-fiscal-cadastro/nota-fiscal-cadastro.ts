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
    numeroSequencial: 0, 
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
      error: (err) => console.error(err)
    });
  }

  adicionarItem(): void {
    this.nota.itens.push({ produtoId: null, quantidade: 1 });
  }

  removerItem(index: number): void {
    if (this.nota.itens.length > 1) {
      this.nota.itens.splice(index, 1);
    }
  }

  salvar(): void {
    const itensInvalidos = this.nota.itens.some(i => !i.produtoId);
    if (itensInvalidos) {
      alert('Por favor selecione o produto em todos os itens da nota');
      return;
    }
    this.notaService.criarNota(this.nota as any).subscribe({
      next: (notaCriada) => {
        const num = notaCriada.numeroSequencial || 'nova';
        alert(`Nota Fiscal #${num} emitida com sucesso contendo ${this.nota.itens.length} itens!`);
        this.router.navigate(['/notas']);
      },
      error: (err) => {
        console.error(err);
        alert('Erro ao emitir nota');
      }
    });
  }
}