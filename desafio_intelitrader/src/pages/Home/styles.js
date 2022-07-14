import styled from 'styled-components';

export const Container = styled.div `
    margin-top: 45px;
    display: flex;
    flex-direction: column;

    section{
        display: flex;
        justify-content: center;
        align-items: center;
        margin-bottom: 30px;
    }

    button{
        margin: auto;
        width: 150px;
    }

    button:hover{
        background-color: #FF8000;
    }
`

export const FileArea = styled.div `
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
    margin-right: 20px;

    label{
        margin-bottom: 10px;
        font-size: 1em;
    }
`