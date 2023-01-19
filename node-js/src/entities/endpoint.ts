import { Root } from './root';

export interface Endpoint extends Root {
  channels: Array<string>;

  enabled: boolean;

  eventTypes: Array<string>;

  name: string;

  secrets: Array<string>;

  uid: string;

  url: string;
}
