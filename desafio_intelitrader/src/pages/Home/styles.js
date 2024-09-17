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

    a{
        display: inline-block;
        margin: auto;
    }

    button{
        width: 150px;
    }

    @media screen and (max-width: 992px) {
        section{
            flex-direction: column;
        }
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

    @media screen and (max-width: 992px) {
        margin: 0 0 20px 0;
    }
`
