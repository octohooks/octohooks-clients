# Octohooks (cURL)

## Getting Started

### Usage

#### POST Application

```bash
curl -X 'POST' \
  'https://api.octohooks.com/api/v1/applications' \
  -H 'accept: application/json' \ 
  -H 'Authorization: AUTH_TOKEN' \
  -H 'Content-Type: application/json' \
  -d '{
  "name": "My Application",
  "uid": "my-application"
}'
```

#### POST Endpoint

```bash
curl -X 'POST' \
  'https://api.octohooks.com/api/v1/applications/my-application/endpoints' \
  -H 'accept: application/json' \
  -H 'Authorization: AUTH_TOKEN' \
  -H 'Content-Type: application/json' \
  -d '{
  "channels": [],
  "enabled": true,
  "eventTypes": ["user.created"],
  "headers": {},
  "name": "My Endpoint",
  "uid": "my-endpoint",
  "url": "https://...."
}'
```

#### POST Message

```bash
curl -X 'POST' \
  'https://api.octohooks.com/api/v1/applications/my-application/messages' \
  -H 'accept: application/json' \ 
  -H 'Authorization: AUTH_TOKEN' \
  -H 'Content-Type: application/json' \
  -d '{
  "channels": [],
  "eventType": "user.created",
  "uid": "my-message",
  "payload": { "email": "foo.bar@example.com" }
}'
```
