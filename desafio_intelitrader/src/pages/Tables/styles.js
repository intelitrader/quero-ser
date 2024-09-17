import styled from 'styled-components';

export const Container = styled.div `
    margin-top: 20px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    padding: 0 15px;
`

export const ContainerTables = styled.section `
    margin: 0 auto 20px auto;
    width: 100%;

    div{
        overflow-x: auto;
        margin: 0 auto 20px auto;
    }

    table{
        border: 1px solid white;
        border-spacing: 0;
        border-radius: 8px;
        min-width: 600px;
        max-width: 800px;
        overflow: hidden;
        margin: auto;
    }

    table thead, tbody{
        color: black;
    }
    
    table caption{
        text-transform: uppercase;
        font-weight: 700;
    }

    table caption, table tr th, table tr td{
        padding: 10px;
    }

    table tr th, table tr td{
        text-align: left;
    }

    table thead{
        background-color: rgb(254, 123, 29);
    }

    table tbody tr:nth-child(odd){
        background-color: rgb(191, 191, 191);
    }

    table tbody tr:nth-child(even){
        background-color: #FAAC58;
    }

`

export const ContainerButtons = styled.section `
    margin-bottom: 20px;
    display: flex;
    flex-wrap: wrap;

    button{
        margin-right: 10px;
        width: 300px;
    }

    @media screen and (max-width: 992px) {
        flex-direction: column;
        justify-content: center;
        align-items: center;

        button{
            margin: 0 0 10px 0;
        }
    }
`
