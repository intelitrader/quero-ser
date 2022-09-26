import styled, { createGlobalStyle } from "styled-components";

export const GlobalStyles = createGlobalStyle`
  *{
    margin:0;
    padding:0;
    box-sizing:border-box;
    text-decoration:nome;
    border:nome;
    outline:nome;
    transition: 0.3s ease;
    font-family: 'Josefin Sans', sans-serif;
  }
  body{
    width: 100%;
    height: 100vh;
    justify-content: center;
    background-image: linear-gradient(to right bottom, #000000, #260017, #390032, #40005b, #120a8f);
    display: flex;
    color: white;
  }

  button{
    cursor: pointer;

    &:hover {
      opacity: 0.8
    } 

    &:active {
      opacity: 0.6
    }
  }
`;

export const Container = styled.div`
width: 100%;
padding: 20px 20px;
`;

export const Flex = styled.div`
  display: flex;
  width: 100%;
  align-items: ${(props) => props.aling || 'center'};
  justify-content: ${(props) => props.justify || 'center'};
  flex-direction: ${(props) => props.direction || 'row'};
  gap: ${(props) => props.gap || '16px'};
`;

export const Spacer = styled.div`
  width: 100%;
  margin: ${(props) => props.margin || '20px'};
`;

export const Typography = styled.p`
  font-weight: ${(props) => props.fontWeight || '700'};
  font-size: ${(props) => props.size || '18px'};
  line-height: ${(props) => props.lineHeight || '27px'};
  color: ${(props) => props.primary ? "#000000" : "#EEEEEE"};
`;