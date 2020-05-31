import { createContext, useContext, useEffect } from 'react';
import { string } from 'prop-types';
import * as signalR from '@aspnet/signalr';
import { ToastProvider, useToasts } from 'react-toast-notifications'

export const AuthContext = createContext();

export function useAuth() {
  
  const context = useContext(AuthContext);
  const { authTokens } = context;
  const { addToast } = useToasts();
  useEffect(() => {
   
  const protocol = new signalR.JsonHubProtocol();

  const transport = signalR.HttpTransportType.WebSockets;

  const options = {
    transport,
    logMessageContent: true,
    logger: signalR.LogLevel.Error,
    accessTokenFactory: () => authTokens 
  };

  // create the connection instance
  const connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:44393/notification', options)
    .withHubProtocol(protocol)
    .build();
  
  connection.on('notification', (res) => {
    console.info('Yayyyyy, I just received a notification!!!', res);
    addToast(res, { appearance: 'success' });

  });

  connection.start()
    .then(() => console.info('SignalR Connected'))
    .catch(err => console.error('SignalR Connection Error: ', err));

  return function cleanup() {
    connection.stop();
    };
})
  return context;
}