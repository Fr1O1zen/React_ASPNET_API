import React,{useEffect, useState} from 'react';
import NavBar from './NavBar';
import axios from "axios";
import {TiDelete} from 'react-icons/ti';
import * as signalR from '@microsoft/signalr';

export default function Product(props) {
    
    let [itemnum,setItemnum]=useState(5);
    const [posts, setPosts]=useState([]);
    const [hubConnection, setHubConnection] = useState(null);
       
    useEffect(() => {
        async function fetchData() {
            try {
                for(let i=1 ; i<=itemnum ; i++)
                {
                    let url='https://localhost:5001/api/product/'+i;
                    const response = await axios.get(url);
                    setPosts([...posts, response.data]);
                    console.log(posts);
                }
                
            } catch (error) {
                console.log(error);
            }
        }
 fetchData(); 

           // Utwórz połączenie z hubem SignalR
    const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://localhost:5001/notificationHub") // Ścieżka huba zdefiniowana po stronie serwera
    .configureLogging(signalR.LogLevel.Information)
    .build();

  connection.start()
    .then(() => {
      console.log('Połączono z hubem SignalR');
      setHubConnection(connection);

      // Zarejestruj obsługę zdarzenia ProductDeleted
      connection.on('ProductDeleted', (productId) => {
        alert(`Otrzymano powiadomienie o usunięciu produktu o ID: ${productId}`);
        // Tutaj możesz zaktualizować stan komponentu, aby usunąć produkt z listy bez odświeżania strony
        fetchData();  
      });
    })
    .catch(err => console.error(err));

  return () => {
    if (connection) {
      connection.stop();
    }
  };

    }, []);

       function DelProd(prodId)
       {
         let url='http://localhost:5000/api/product/delete/'+prodId;
         console.log(prodId);
         axios.delete(url)
         .then(() => window.location.reload());
       }
    const arr=posts.map((data,index)=>{
        return(
            <>
                <tr key={data['idprod']}>
                    <td className='tg-0lax'>{data['idprod']}</td>
                    <td className='tg-0lax'>{data['nazwa']}</td>
                    <td className='tg-0lax'>{data['producent']}</td>
                    <td className='tg-0lax'>{data['kategoria']}</td>
                    <td className='tg-0lax'>{data['cenaNetto']}</td>
                    <td className='tg-0lax'>{data['cenaBrutto']}</td>
                    <td className='tg-0lax'>
                        <TiDelete size={30} 
                        color={'red'}
                        onClick={() => { if(window.confirm(`Are you sure you want to delete the post titled "${data['nazwa']}"?`))
                         DelProd(data['idprod']) }}
                        />
                        </td>
                </tr>
                <tr key={data['idprod']}>
            </tr>   
            </>
        )
    })

    return (
        <>
        <div>
            <NavBar/>
            <h1 style={{color:'#ff6347',textAlign:'center'}}> Get API data !</h1>
            <table style={{marginLeft:'auto',marginRight:'auto'}}>
                <tr>
                    <th className='tg-0lax'>idprod</th>
                    <th className='tg-0lax'>nazwa</th>
                    <th className='tg-0lax'>producent</th>
                    <th className='tg-0lax'>kategoria</th>
                    <th className='tg-0lax'>cenaNetto</th>
                    <th className='tg-0lax'>cenaBrutto</th>
                    <th className='tg-0lax'></th>
                </tr>
              { arr}
              </table>
        </div>
        </>
    );
    }