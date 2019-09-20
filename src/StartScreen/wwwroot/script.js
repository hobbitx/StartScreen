document.addEventListener("DOMContentLoaded", function () {
    document.getElementById('view_start-screen').innerHTML = `<link href="https://fonts.googleapis.com/css?family=Montserrat" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Nunito" rel="stylesheet">
        <link href="./start-screen.css" rel="stylesheet" />
        <div id="start-screen">
            <div class="top-section">
                <div class="top-icon">
                    <img src="image/fiat_icon.svg" alt="" />
                </div>
                <div class="greeting-phrase">CENTRAL DE SERVIÇOS FIAT.</div>
                <div class="close-button">
                    <img close-start-screen="true" src="image/close_button.svg" alt="" />
                </div>
            </div>
            <div class="start-screen-content">
                <div class="offer-question">Como podemos te ajudar?</div>
                <div class="question-box">
                    <div class="subject-phrase">CONSULTAR RECALL</div>
                    <div class="ask-question-section">
                        <input id="question-input-recall" class="ask-question-input" placeholder="Digite PLACA ou CHASSI" type="text" name="question" value="" />
                        <div id="click-question-recall" class="question-image-box">
                            <div payload="recall:question-input-recall" class="question-image recall-image"></div>
                        </div>
                    </div>
                </div>
                <div class="subjects-box">
                    <span class="subject-phrase">MAIS FREQUENTES</span>
                    <div>
                        <div class="subject-item"><span payload="Conhecer os carros">CONHECER OS CARROS</span></div>
                        <div class="subject-item"><span payload="Localizar concessionarias">LOCALIZAR CONCESSIONÁRIAS</span></div>
                        <div class="subject-item"><span payload="Condicoes especiais">CONDIÇÕES ESPECIAIS / VENDAS DIRETAS</span></div>
                        <div class="subject-item"><span payload="Vagas de trabalho">VAGAS DE TRABALHO</span></div>
                    </div>
                </div>
                <div class="subjects-box">
                    <span class="subject-phrase">SEU CARRO</span>
                    <div>
                        <div class="subject-item"><span payload="Agendar servico">AGENDAR UM SERVIÇO</span></div>
                        <div class="subject-item"><span payload="Consultar manual">MANUAIS</span></div>
                        <div class="subject-item"><span payload="Ver opcionais">OPCIONAIS</span></div>
                        <div class="subject-item"><span payload="Checar assistencia">ASSISTÊNCIA 24 HORAS</span></div>
                        <div class="subject-item"><span payload="Dados tecnicos">DADOS TÉCNICOS</span></div>
                    </div>
                </div>
                <div class="question-box">
                    <div class="ask-question-phrase">NÃO ENCONTROU O QUE BUSCAVA?</div>
                    <div class="ask-question-section">
                        <input id="question-input" class="ask-question-input" placeholder="Digite a sua dúvida aqui" type="text" name="question" value="" />
                        <div id="click-question" class="question-image-box">
                            <div payload="question:question-input" class="question-image search-image"></div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="bottom-section" rel="bookmark">
                <div class="bottom-content">
                    <img src="image/vector.svg" class="scroll-image"><span class="scroll-phrase">DESLIZE PARA MAIS OPÇÕES</span>
            </div>
                </div>
`
});