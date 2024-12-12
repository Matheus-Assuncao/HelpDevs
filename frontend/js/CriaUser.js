export default function criaUser(){
    
document.getElementById('cadastraForm').addEventListener('submit', async (event) => {
    event.preventDefault(); // Impede o comportamento padrão do formulário

    const name = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    const url = "http://localhost:5244/api/users"; // URL da sua API
    const data = { name, password };

    try {
        const response = await fetch(url, {
            method: 'POST', // Use POST ou PUT conforme necessário
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (response.ok) {
            // Verifica se há conteúdo na resposta
            const text = await response.text(); // Lê a resposta como texto
            const result = text ? JSON.parse(text) : {}; // Converte para JSON, se houver conteúdo
            alert('Usuário cadastrado com sucesso!');
            console.log(result);
            window.location.href = '../views/login.html'
        } else {
            alert('Erro ao cadastrar usuário');
            console.error('Erro:', response.statusText);
        }
    } catch (error) {
        alert('Erro na requisição: ' + error.message);
        console.error(error);
    }
});
}
