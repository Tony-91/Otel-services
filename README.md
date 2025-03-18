# Log Aggregation with Loki, Grafana, and OpenTelemetry

This project sets up a Docker-based environment using **Loki**, **Grafana**, and **OpenTelemetry Collector** to create a full observability pipeline. The goal of this setup is to collect, store, visualize, and analyze logs from your applications in a centralized manner.

## Services Overview

### 1. **Loki**: Log Aggregation System
**Loki** is a highly efficient log aggregation system designed to collect, index, and store logs. It is optimized for storing and searching logs in a way that's highly scalable and cost-effective.

#### Key Features of Loki:
- **Log Aggregation**: Loki collects logs from various sources (in this case, the OpenTelemetry Collector) and stores them in an optimized format for fast searching and querying.
- **Indexing**: It uses a simple indexing scheme based on time and labels (e.g., job, application name) to index logs, making it easy to search and filter log data.
- **Scalable**: Loki is built to scale with your environment, allowing it to handle large volumes of logs efficiently.
- **Low Overhead**: Unlike traditional logging systems that use expensive indexing on every log line, Loki indexes only the metadata (labels), making it efficient in terms of storage and performance.

**In this project**:
- Loki is responsible for receiving log data and storing it in a persistent storage system (usually filesystem or object storage).
- Logs are stored in **chunks** (grouped log lines) and **indexes** (used to search the logs).
- Logs are queried via the Loki API, which provides an interface for tools like Grafana to visualize the logs.

---

### 2. **Grafana**: Data Visualization Platform
**Grafana** is an open-source platform for monitoring and observability that allows you to visualize logs, metrics, and other data in real-time. It supports a wide range of data sources, including Loki.

#### Key Features of Grafana:
- **Dashboards**: Grafana allows users to create custom dashboards that can display logs, metrics, and other performance data from various sources.
- **Data Sources**: Grafana connects to multiple data sources like Loki (for logs), Prometheus (for metrics), and many others, enabling unified visualization.
- **Alerting**: You can configure alerts in Grafana to notify you of specific log patterns or anomalies.
- **Querying**: Using Grafana's query editor, you can query the Loki data source to filter, group, and search logs.

**In this project**:
- Grafana connects to the Loki data source to visualize logs in real-time.
- It is used to create powerful visualizations like log panels, time-series data, and alerts for operational monitoring.
- Through Grafana's flexible query system, users can easily drill down into logs to investigate issues or analyze patterns.

---

### 3. **OpenTelemetry Collector**: Logs Collection and Exporting
**OpenTelemetry** is an open-source set of APIs, libraries, agents, and instrumentation to provide observability through metrics, logs, and traces. The **OpenTelemetry Collector** is a component that collects telemetry data from various sources and exports it to different backends, like Loki in this case.

#### Key Features of OpenTelemetry Collector:
- **Log Collection**: The collector gathers logs from applications or services that use OpenTelemetry SDKs.
- **Protocol Support**: It supports various protocols like **OTLP** (OpenTelemetry Protocol), which is used for receiving logs over gRPC and HTTP.
- **Exporting**: After collecting logs, the collector can export them to different systems such as Loki, Prometheus, and others.
- **Processing**: The collector can also perform some processing on the logs, like batching them or adding additional metadata (e.g., service name, job name).

**In this project**:
- The OpenTelemetry Collector receives logs via the **OTLP** protocol over both gRPC and HTTP.
- It processes logs by adding resource attributes (like the service name or job) to help categorize the logs.
- The collector exports logs to Loki using the **Loki exporter** so that they can be stored and visualized.
- The collector exposes a health check endpoint to ensure that it's running correctly and processing logs.

---

## Requirements

To get started, you'll need:

- **Docker**: For running the services inside containers.
- **Docker Compose**: To define and run multi-container Docker applications. This project uses Docker Compose to manage and start the Loki, Grafana, and OpenTelemetry Collector services.

---

## Getting Started

### 1. Clone the repository

```bash
git clone <your-repository-url>
cd <your-repository-directory>
