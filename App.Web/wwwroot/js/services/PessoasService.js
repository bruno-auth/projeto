async function PessoaListaPessoas(busca, pesoMenor, pesoMaior) {
    return new Promise((resolve, reject) => {
        Post('Pessoa/ListaPessoas?nome=' + busca + '&pesoMinimo=' + pesoMenor + '&pesoMaximo=' + pesoMaior).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaBuscaPorId(id) {
    return new Promise((resolve, reject) => {
        Get('Pessoa/BuscaPorId?id=' + id).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

async function PessoaSalvar(obj) {
    return new Promise((resolve, reject) => {
        Post('Pessoa/Salvar', obj).then(function (response) {
            if (response.status === 'success') {
                resolve(response.data);
            } else {
                reject(response.message);
            }
        }, function (err) {
            console.error(err);
            reject('Erro desconhecido');
        });
    });
}

