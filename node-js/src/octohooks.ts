import axios from 'axios';
import { Application, Endpoint } from './entities';
import { EndpointRequest } from './value-objects';

export class Octohooks {
  public readonly application: OctohooksApplication;

  public readonly endpoint: OctohooksEndpoint;

  public readonly message: OctohooksMessage;

  constructor(protected token: string, protected domain: string = 'https://api.octohooks.com') {
    this.application = new OctohooksApplication(
      `${this.domain}/api/v1`,
      this.token
    );

    this.endpoint = new OctohooksEndpoint(`${this.domain}/api/v1`, this.token);

    this.message = new OctohooksMessage(`${this.domain}/api/v1`, this.token);
  }
}

export class OctohooksApplication {
  constructor(protected url: string, protected token: string) {}

  public async create(application: {
    name: string;
    uid: string;
  }): Promise<Application> {
    const response = await axios.post<Application>(
      `${this.url}/applications`,
      application,
      {
        headers: {
          Authorization: `Bearer ${this.token}`,
        },
      }
    );

    return response.data;
  }

  public async delete(applicationId: string): Promise<Application> {
    const response = await axios.delete<Application>(
      `${this.url}/applications/${applicationId}`,
      {
        headers: {
          Authorization: `Bearer ${this.token}`,
        },
      }
    );

    return response.data;
  }

  public async find(applicationId: string): Promise<Application | null> {
    const response = await axios.get<Application>(
      `${this.url}/applications/${applicationId}`,
      {
        headers: {
          Authorization: `Bearer ${this.token}`,
        },
        validateStatus: (status) => {
          return status === 200 || status === 404 ? true : false;
        },
      }
    );

    return response.data;
  }
}

export class OctohooksEndpoint {
  constructor(protected url: string, protected token: string) {}

  public async create(
    applicationId: string,
    endpointRequest: EndpointRequest
  ): Promise<Endpoint> {
    const response = await axios.post<Endpoint>(
      `${this.url}/applications/${applicationId}/endpoints`,
      endpointRequest,
      {
        headers: {
          Authorization: `Bearer ${this.token}`,
        },
      }
    );

    return response.data;
  }

  public async find(
    applicationId: string,
    endpointId: string
  ): Promise<Endpoint | null> {
    const response = await axios.get<Endpoint>(
      `${this.url}/applications/${applicationId}/endpoints/${endpointId}`,
      {
        headers: {
          Authorization: `Bearer ${this.token}`,
        },
        validateStatus: (status) => {
          return status === 200 || status === 404 ? true : false;
        },
      }
    );

    return response.data;
  }
}

export class OctohooksMessage {
  constructor(protected url: string, protected token: string) {}

  public async create(
    applicationId: string,
    message: {
      eventType: string;
      channels: Array<string>;
      payload: any;
    }
  ): Promise<Endpoint> {
    const response = await axios.post<Endpoint>(
      `${this.url}/applications/${applicationId}/messages`,
      message,
      {
        headers: {
          Authorization: `Bearer ${this.token}`,
        },
      }
    );

    return response.data;
  }
}
